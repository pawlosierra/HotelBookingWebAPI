﻿using HotelBookingWebAPI.Domain.Models.Bookings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingWebAPI.Application.Queries.Bookings.GetRooms
{
    public class GetRooms : IRequest<IEnumerable<Room>>
    {
    }
}