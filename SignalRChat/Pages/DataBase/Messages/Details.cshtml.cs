﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRChat.Data;
using SignalRChat.Models;

namespace SignalRChat.Pages.DataBase.Messages
{
    public class DetailsMessageModel : PageModel
    {
        private readonly SignalRChat.Data.SignalRChatContext _context;

        public DetailsMessageModel(SignalRChat.Data.SignalRChatContext context)
        {
            _context = context;
        }

        public Models.Messages Messages { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Messages = await _context.Messages.FirstOrDefaultAsync(m => m.ID == id);

            if (Messages == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
