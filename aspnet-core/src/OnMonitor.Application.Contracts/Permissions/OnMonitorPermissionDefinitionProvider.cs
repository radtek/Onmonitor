﻿using OnMonitor.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace OnMonitor.Permissions
{
    public class OnMonitorPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(OnMonitorPermissions.GroupName);


            myGroup.AddPermission("DVR_Check");
            myGroup.AddPermission("CCTV_Modification");
            myGroup.AddPermission("CCTV_VideoViewing");



            //Define your own permissions here. Example:
            //myGroup.AddPermission(OnMonitorPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<OnMonitorResource>(name);
        }
    }
}
