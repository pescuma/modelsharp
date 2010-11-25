using System.Collections.Generic;

namespace org.pescuma.ModelSharp.Core
{
	public class ModelProcessorResult
	{
		public bool Success;
		public readonly List<string> EditableFilenames = new List<string>();
		public readonly List<string> NotToChangeFilenames = new List<string>();
		public readonly List<Message> Messages = new List<Message>();

		public class Message
		{
			public readonly bool Error;
			public readonly string Description;
			public readonly int Line;
			public readonly int Column;

			public Message(bool error, string description, int line, int column)
			{
				Error = error;
				Description = description;
				Line = line;
				Column = column;
			}
		}
	}
}
