﻿using Gifits.Korsio.Authorization.Application.Contracts.RefreshTokenRepository;
using Gifits.Korsio.Authorization.Domain.Models.Authorization;
using Gifits.Korsio.Authorization.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Gifits.Korsio.Authorization.Infrastructure.Repositories.RefreshTokenRepository
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly KorsioDbContext _korsioDbContext;
        public RefreshTokenRepository(KorsioDbContext korsioDbContext)
        {
            _korsioDbContext = korsioDbContext;
        }
        public async Task<KtRefreshToken> Create(KtRefreshToken refreshToken)
        {
            try
            {
                _korsioDbContext.RefreshTokens.Add(refreshToken);
                await _korsioDbContext.SaveChangesAsync();
                return refreshToken;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<KtRefreshToken> GetCurrentByUserId(int userId)
        {
            try
            {
                return await _korsioDbContext.RefreshTokens
                        .Where(x => x.UserId == userId 
                        && x.ExpiresOnUtc >= DateTime.UtcNow)
                        .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<KtRefreshToken> GetCurrentToken(string token)
        {
            try
            {
                return await _korsioDbContext.RefreshTokens
                    .Include(x => x.User)
                    .FirstOrDefaultAsync(x => x.Token == token);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<KtRefreshToken> Update(KtRefreshToken entity)
        {
            try
            {
                _korsioDbContext.RefreshTokens.Update(entity);
                await _korsioDbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
