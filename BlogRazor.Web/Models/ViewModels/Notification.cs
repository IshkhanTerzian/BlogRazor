﻿using BlogRazor.Web.Enums;

namespace BlogRazor.Web.Models.ViewModels
    {
    public class Notification
        {
        public string Message { get; set; }

        public NotificationType Type { get; set; }
        }
    }
