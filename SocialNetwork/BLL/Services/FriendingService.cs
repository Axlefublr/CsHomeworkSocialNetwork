using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Services;

public class FriendingService
{

    IFriendRepository friendRepository;
    IUserRepository userRepository;

    public FriendingService()
    {
        userRepository = new UserRepository();
        friendRepository = new FriendRepository();
    }

    public void AddFriend(FriendingData friendingData)
    {
        var findUserEntity = userRepository.FindByEmail(friendingData.FriendEmail);
        if (findUserEntity is null) throw new UserNotFoundException();

        FriendEntity friendEntity = new()
        {
            user_id = friendingData.UserId,
            friend_id = friendingData.FriendId
        };

        if (friendRepository.Create(friendEntity) == 0) throw new Exception();

    }

}