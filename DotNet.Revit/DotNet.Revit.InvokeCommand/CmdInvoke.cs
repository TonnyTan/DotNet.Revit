﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using System.Diagnostics;

namespace DotNet.Revit.InvokeCommand
{
    [Transaction(TransactionMode.Manual)]
    public class CmdInvoke : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {



            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class CmdInvokeTest : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Autodesk.Windows.ComponentManager.ItemExecuted += ComponentManager_ItemExecuted;

            return Result.Succeeded;
        }

        void ComponentManager_ItemExecuted(object sender, Autodesk.Internal.Windows.RibbonItemExecutedEventArgs e)
        {
            if (e.Item == null)
                return;

            var id = UIFramework.ControlHelper.GetCommandId(e.Item);
            Debug.WriteLine(string.Format("Text: {0}   ID: {1}", e.Item.Text, id));
        }
    }
}
