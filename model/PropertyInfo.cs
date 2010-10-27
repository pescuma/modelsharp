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

namespace org.pescuma.ModelSharp.Model
{
    public class PropertyInfo : BaseFieldInfo
    {
        public readonly bool Lazy;
        public readonly int Order = -1;

        public FieldInfo Field; 
        public MethodInfo Getter;
        public MethodInfo Setter;
        public MethodInfo LazyInitializer;

        public PropertyInfo(string name, string type, bool readOnly, bool lazy) 
            : base(name, type, true, readOnly)
        {
            Lazy = lazy;

            Field = new FieldInfo(GetFieldName(), TypeName, false, false);

            string getter = GetGetterName();
            if (getter != null)
                Getter = new MethodInfo(getter, TypeName);

            string setter = GetSetterName();
            if (setter != null)
                Setter = new MethodInfo(setter, "void", TypeName);

            string lazyIntializer = GetLazyInitializerName();
            if (lazyIntializer != null)
                LazyInitializer = new MethodInfo(lazyIntializer);
        }

        public string GetLazyInitializerName()
        {
            if (!Lazy)
                return null;
            return "LazyInit" + Name;
        }

        public string GetGetterName()
        {
            if (TypeName == "bool" || TypeName == "Boolean")
                return "Is" + Name;
            else
                return "Get" + Name;
        }

        public string GetSetterName()
        {
            if (ReadOnly)
                return null;
            return "Set" + Name;
        }

        public string GetFieldName()
        {
            return "_" + StringUtils.FirstLower(Name);
        }
    }
}