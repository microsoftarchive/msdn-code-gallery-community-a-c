// =====================================================================
//  This file is part of the Microsoft Dynamics CRM SDK code samples.
//
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
//
//  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
// =====================================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.UI.Notifications;

namespace CRMtoGoBackgroundTasks
{
    public sealed class UpdateSystemUserTimeZone : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral _deferral = taskInstance.GetDeferral();

            var notifier = ToastNotificationManager.CreateToastNotifier();
            var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
            var toastBody = toastXml.GetElementsByTagName("text");
            (toastBody[0] as XmlElement).InnerText = "Timezone has been changed!";
            // Add launch information
            ((XmlElement)toastXml.GetElementsByTagName("toast").First()).
                SetAttribute("launch", "{'type':'toast','page':'settings','trigger':'UpdateSystemUserTimeZone','timezonename':'"
                +TimeZoneInfo.Local.DisplayName.Replace("UTC","GMT")+"'}");
            var toast = new ToastNotification(toastXml);
            notifier.Show(toast);
                
            _deferral.Complete();
        }
    }
}
