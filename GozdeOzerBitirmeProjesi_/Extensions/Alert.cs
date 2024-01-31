using GozdeOzerBitirmeProjesi_.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GozdeOzerBitirmeProjesi_.Extensions
{
    public class Alert
    {
        private AlertType _type;

        private string _message;
        public Alert(string message, AlertType type)
        {
            _type = type;
            _message = message;
        }
        internal dynamic Get()
        {

            string text = "<div class='alert alert-{0}' role='alert'> {1} </div>";
            string className = string.Empty;
            switch (_type)
            {
                case AlertType.Success:
                    className = "success";
                    break;
                case AlertType.Info:
                    className = "info";
                    break;
                case AlertType.Danger:
                    className = "danger";
                    break;
                case AlertType.Warning:
                    className = "warning";
                    break;

            }
            return string.Format(text, className, _message);
        }
    }
}