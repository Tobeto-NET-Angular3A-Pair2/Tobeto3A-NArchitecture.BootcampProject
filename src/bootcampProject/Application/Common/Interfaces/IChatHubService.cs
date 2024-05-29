﻿using Application.Features.Messages.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces;
public interface IChatHubService
{
    Task SendMessageAsync(CreatedMessageResponse response, CancellationToken cancellationToken);
}
