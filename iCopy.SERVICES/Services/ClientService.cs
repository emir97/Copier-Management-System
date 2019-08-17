﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using iCopy.Database.Context;
using iCopy.Model.Response;
using iCopy.SERVICES.IServices;

namespace iCopy.SERVICES.Services
{
    public class ClientService : CRUDService<Database.Client, Model.Request.Client, Model.Request.Client, Model.Response.Client, object, int>, IClientService
    {
        private readonly IUserService UserService;
        private readonly IPersonService PersonService;

        public ClientService(DBContext ctx, IMapper mapper, IUserService UserService, IPersonService PersonService) : base(ctx, mapper)
        {
            this.UserService = UserService;
            this.PersonService = PersonService;
        }

        public override async Task<Client> InsertAsync(Model.Request.Client entity)
        {
            Database.Client client = mapper.Map<Database.Client>(entity);
            try
            {
                Model.Response.ApplicationUser user = await UserService.InsertAsync(entity.ApplicationUserInsert);
                Model.Response.Person person = await PersonService.InsertAsync(entity.Person);
                client.ApplicationUserId = user.ID;
                client.PersonId = person.ID;
                ctx.Clients.Add(client);
                await ctx.SaveChangesAsync();

                // TODO: Dodati log
            }
            catch (Exception e)
            {
                // TODO: Dodati log
                throw e;
            }

            return mapper.Map<Model.Response.Client>(client);
        }
    }
}
