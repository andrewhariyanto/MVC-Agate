#!/usr/bin/env bash

curl -fsSL https://dot.net/v1/dotnet-install.sh | bash -s -- -i /usr/share/dotnet


# Ensure UNITY_DIR is set
if [ -z "$UNITY_DIR" ]; then
  echo "Error: UNITY_DIR is not set. Please specify your Unity project folder."
  exit 1
fi

# Set the correct Unity executable path
UNITY_EXECUTABLE=/opt/unity/Editor/Unity  # Update this if needed

# Run Unity in headless mode to sync solution for Rider
${UNITY_EXECUTABLE:-xvfb-run --auto-servernum --server-args='-screen 0 640x480x24' unity-editor} \
  -batchmode -quit -projectPath "$UNITY_DIR" -executeMethod Packages.Rider.Editor.RiderScriptEditor.SyncSolution

echo "Unity Rider solution sync completed."