using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Example.Scene.Gameplay.Bed
{
    public class BedController : ObjectController<BedController, BedView>
    {
        public override void SetView(BedView view)
        {
            base.SetView(view);
        }
    }
}
