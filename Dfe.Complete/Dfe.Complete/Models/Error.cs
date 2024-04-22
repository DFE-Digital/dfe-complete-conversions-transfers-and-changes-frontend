﻿using System.Collections.Generic;

namespace Dfe.ManageFreeSchoolProjects.Models
{
	public class Error
	{
		public string Key { get; set; }
		public string Message { get; set; }
		public List<string> InvalidInputs { get; set; } = new List<string>();
	}
}
