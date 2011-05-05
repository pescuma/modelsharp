//----------------------
// <auto-generated>
//     Automatically generated by Model#
// </auto-generated>
//----------------------
// DO NOT EDIT THIS FILE

using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Diagnostics;
using System;

namespace examples.immutable
{

	[GeneratedCode("Model#", "0.2.0.0")]
	public class LineBuilder
	{
		private Point p1;
		private Point p2;
		private Point dir;
		private readonly List<Point> border = new List<Point>();
		
		public virtual LineBuilder Set(Line other)
		{
			SetP1(other.P1);
			SetP2(other.P2);
			SetDir(other.Dir);
			ClearBorder();
			AddToBorder(other.Border);
			return this;
		}
		
		public virtual LineBuilder SetP1(Point p1)
		{
			this.p1 = p1;
			return this;
		}
		
		public virtual LineBuilder SetP2(Point p2)
		{
			this.p2 = p2;
			return this;
		}
		
		public virtual LineBuilder SetDir(Point dir)
		{
			this.dir = dir;
			return this;
		}
		
		public virtual LineBuilder ClearBorder()
		{
			this.border.Clear();
			return this;
		}
		public virtual LineBuilder AddToBorder(Point border)
		{
			this.border.Add(border);
			return this;
		}
		public virtual LineBuilder AddToBorder(IEnumerable<Point> border)
		{
			this.border.AddRange(border);
			return this;
		}
		
		public virtual Line Build()
		{
			return new Line(this.p1, this.p2, this.dir, this.border);
		}
	}
	
}