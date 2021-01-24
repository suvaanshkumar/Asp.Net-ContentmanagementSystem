using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContenManagementSystem.Models
{
    /// <summary>
    /// Model containing styling details of the entity. Scope to add authentication data as well.
    /// </summary>
    public class SettingsModel
    {
        Dictionary<string, string> styling = new Dictionary<string, string>();
    }
}