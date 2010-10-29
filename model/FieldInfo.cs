﻿//
// Copyright 2010 Ricardo Pescuma Domenecci
// 
// This file is part of Model#.
// 
// Model# is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
// 
// Model# is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
// FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License along with Model#. If not, see <http://www.gnu.org/licenses/>.
// 

namespace org.pescuma.ModelSharp.Model
{
    public class FieldInfo : BaseFieldInfo
    {
        private string _defaultValue;

        public FieldInfo(string name, string type, bool @public, bool readOnly)
            : base(name, type, @public, readOnly)
        {
        }

        public string DefaultValue
        {
            get { return _defaultValue; }
            set
            {
                _defaultValue = value;

                if (TypeName == "string" && (_defaultValue[0] != '"' || _defaultValue[-1] != '"'))
                {
                    _defaultValue = _defaultValue.Replace("\"", "\\\"");
                    _defaultValue = "\"" + _defaultValue + "\"";
                }
            }
        }
    }
}