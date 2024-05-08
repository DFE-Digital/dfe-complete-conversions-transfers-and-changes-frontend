﻿namespace Dfe.Complete.Constants
{
    public static class RouteConstants
    {
        public const string ProjectsInProgress = "/projects/all/in-progress/all";

        // Transfer
        public const string TransferProjectTaskList = "/projects/{0}/transfer/tasks";

        public const string ViewHandoverWithDeliveryOfficerTask = TransferProjectTaskList + "/handover";
        public const string EditHandoverWithDeliveryOfficerTask = ViewHandoverWithDeliveryOfficerTask + "/edit";
    }
}