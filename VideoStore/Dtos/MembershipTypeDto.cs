﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoStore.Dtos
{
    public class MembershipTypeDto
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public byte DiscountRate { get; set; }


    }
}