﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAppClassDemo.Models
{
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsSubscribedToNewsLetter { get; set; }
		public MembershipType MembershipType { get; set; }
		public int MembershipTypeId { get; set; }
	}
}