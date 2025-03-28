﻿using MySocial.Domain.Entities;

namespace MySocial.Domain.Interfaces;
public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task<bool> IsEmailUniqueAsync(string email);
}
