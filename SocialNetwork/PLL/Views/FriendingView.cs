using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views;

public class FriendingView
{
    UserService userService;
    FriendingService friendingService;
    public FriendingView(FriendingService friendingService, UserService userService)
    {
        this.friendingService = friendingService;
        this.userService = userService;
    }

    public void Show(User user)
    {
        FriendingData friendingData = new();

        Console.Write("Введите почтовый адрес получателя: ");
        friendingData.FriendEmail = Console.ReadLine();

        friendingData.UserId = user.Id;

        try
        {
            friendingService.AddFriend(friendingData);
            SuccessMessage.Show("Пользователь успешно добавлен в друзья!");

            user = userService.FindById(user.Id);
        }

        catch (UserNotFoundException)
        {
            AlertMessage.Show("Пользователь не найден");
        }

        catch (ArgumentNullException)
        {
            AlertMessage.Show("Введите корректное значение!");
        }

        catch (Exception)
        {
            AlertMessage.Show("Произошла ошибка при добавлении в друзья!");
        }

    }
}