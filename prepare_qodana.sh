#!/usr/bin/env bash

<< check
curl -fsSL https://dot.net/v1/dotnet-install.sh | bash -s -- -i /usr/share/dotnet

# Ensure UNITY_PROJECT_PATH is set
if [ -z "$UNITY_PROJECT_PATH" ]; then
  echo "Error: UNITY_PROJECT_PATH is not set. Please specify your Unity project folder."
  exit 1
fi

# Ensure EDITOR_PATH is set
if [ -z "$UNITY_EDITOR_PATH" ]; then
  echo "Error: UNITY_EDITOR_PATH is not set. Please specify the Unity executable path."
  exit 1
fi

# Ensure Unity executable exists
if [ ! -f "$UNITY_EDITOR_PATH" ]; then
  echo "Error: Unity executable not found at $UNITY_EDITOR_PATH"
  exit 1
fi

# Run Unity in headless mode to sync solution for Rider
echo "Running Unity to sync Rider solution..."

UNITY_EXECUTABLE="$UNITY_EDITOR_PATH"

${UNITY_EXECUTABLE:-xvfb-run --auto-servernum --server-args='-screen 0 640x480x24' "$UNITY_EDITOR_PATH"} \
  -batchmode -quit -projectPath "$UNITY_PROJECT_PATH" -executeMethod Packages.Rider.Editor.RiderScriptEditor.SyncSolution

echo "Unity Rider solution sync completed."
check