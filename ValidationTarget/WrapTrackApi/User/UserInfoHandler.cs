// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserInfoHandler.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the UserInfoHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackApi.User
{
    using System;

    using Mir.Stf.Utilities.Interfaces;

    using Newtonsoft.Json.Linq;

    using WrapTrack.Stf.WrapTrackApi.Configuration;

    //// using https://www.newtonsoft.com/json/help/html/QueryJsonSelectTokenWithLinq.htm

    /// <summary>
    /// The user info handler.
    /// </summary>
    internal class UserInfoHandler : InfoHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfoHandler"/> class.
        /// </summary>
        /// <param name="stfLogger">
        /// The stf logger.
        /// </param>
        /// <param name="wtApiConfiguration">
        /// The wt api configuration.
        /// </param>
        public UserInfoHandler(IStfLogger stfLogger, WtApiConfiguration wtApiConfiguration)
            : base(stfLogger, wtApiConfiguration)
        {
        }

        /// <summary>
        /// The user info by id.
        /// </summary>
        /// <param name="internalId">
        /// The internal id.
        /// </param>
        /// <returns>
        /// The <see cref="UserInfo"/>.
        /// </returns>
        public UserInfo UserInfoById(string internalId)
        {
            if (string.IsNullOrWhiteSpace(internalId))
            {
                return null;
            }

            var uri = GetUserRestInfoByInternalIdUri(internalId);
            var info = GetWrapRestInfo(uri);
            var retVal = UserInfoMapper(info.Result);

            return retVal;
        }

        /// <summary>
        /// The user info by user name.
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <returns>
        /// The <see cref="UserInfo"/>.
        /// </returns>
        public UserInfo UserInfoByUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return null;
            }

            var uri = GetUserRestInfoByUserName(userName);
            var info = GetWrapRestInfo(uri);
            var retVal = UserInfoMapper(info.Result);

            return retVal;
        }

        /// <summary>
        /// The end user collection.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool EndUserCollection(int userId)
        {
            var uri = $"user/endcollection/{userId}";
            var retVal = PutWrapRestInfo(uri);

            return true;
        }

        /// <summary>
        /// The get user rest info by internal id uri.
        /// </summary>
        /// <param name="internalId">
        /// The internal id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetUserRestInfoByInternalIdUri(string internalId)
        {
            if (string.IsNullOrEmpty(internalId))
            {
                return null;
            }

            var retVal = $"user/{internalId.Trim()}/BamseNotUsed";

            return retVal;
        }

        /// <summary>
        /// The get user rest info by user name.
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetUserRestInfoByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return null;
            }

            var retVal = $"user/0/{userName.Trim()}";

            return retVal;
        }

        /// <summary>
        /// The user info mapper.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        /// <returns>
        /// The <see cref="UserInfo"/>.
        /// </returns>
        private UserInfo UserInfoMapper(JObject info)
        {
            if (info == null)
            {
                return null;
            }

            UserInfo retVal;

            StfLogger.LogDebug($"UserInfoMapper: Got info = [{info}]");

            try
            {
                var bent = new UserInfo
                {
                    UserId = info["user_id"]?.ToString(),
                    UserName = info["user_name"]?.ToString(),
                };

                retVal = bent;
            }
            catch (Exception ex)
            {
                StfLogger.LogError($"UserInfoMapper: Got ex = [{ex}]");

                return null;
            }

            return retVal;
        }
    }
}
