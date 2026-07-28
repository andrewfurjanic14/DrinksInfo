using System;
using System.Collections.Generic;
using System.Text;

namespace DrinksInfo.Views
{
    public enum UserAction
    {
        Exit,
        Select
    }

    public record UserOption<T>(
        string Label,
        UserAction Action,
        T? Data = default
        )
    {
        public override string ToString()
        {
            return Label;
        }
    }

    public static class UserOptionExtensions
    {
        public static List<UserOption<T>> ToUserOptions<T>(this IEnumerable<T> collection, Func<T, string> labelSelector)
        {
            return [.. collection
                .Select(item => new UserOption<T>(
                    labelSelector(item),
                    UserAction.Select,
                    item))];
        }
    }
}
