//
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

using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace org.pescuma.ModelSharp.Model
{
    public class BaseFieldInfo
    {
        public readonly string Name;
        public readonly string PrivateName;
        public readonly string PublicName;
        public readonly string VarName;
        public readonly string TypeName;
        public readonly string DefineName;
        public readonly bool Public;
        public readonly bool ReadOnly;
        public readonly List<string> Annotations = new List<string>();

        public BaseFieldInfo(string name, string type, bool @public, bool readOnly)
        {
            Contract.Requires(StringUtils.IsValidVariableName(name));
            Contract.Requires(StringUtils.IsValidTypeName(type));
            Contract.Ensures(StringUtils.IsValidVariableName(Name));
            Contract.Ensures(StringUtils.IsValidVariableName(PrivateName));
            Contract.Ensures(StringUtils.IsValidVariableName(PublicName));
            Contract.Ensures(StringUtils.IsValidVariableName(VarName));
            Contract.Ensures(StringUtils.IsValidTypeName(TypeName));
            Contract.Ensures(StringUtils.IsValidVariableName(DefineName));

            Name = name;
            PublicName = StringUtils.FirstUpper(name);
            PrivateName = "_" + StringUtils.FirstLower(name);
            VarName = StringUtils.FirstLower(name);
            TypeName = type;
            DefineName = StringUtils.ToDefineName(name);
            Public = @public;
            ReadOnly = readOnly;
        }
    }
}