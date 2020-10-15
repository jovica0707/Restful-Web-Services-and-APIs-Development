using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Shared.Exceptions
{
    class Status400BadRequest : Exception
    {
        public Status400BadRequest(string message) : base(message)
        {

        }
    }
}
