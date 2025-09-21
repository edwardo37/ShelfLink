using ShelfLink.DTOs;
using ShelfLink.Models;

namespace ShelfLink.Repositories
{
    /// <summary>
    /// Interface definining ShelfLink repository
    /// </summary>
    public interface IShelfLinkRepository
    {
        /// <summary>
        /// Save a new title to the repository.
        /// </summary>
        /// <param name="title">The title to create</param>
        /// <returns>The newly created title object, with EntityBase updated</returns>
        Title CreateTitle(Title title);
        /// <summary>
        /// Update an existing title in the repository.
        /// </summary>
        /// <param name="title">The title's model to update</param>
        /// <returns>The newly updated title, null if not found</returns>
        Title? UpdateTitle(Title title);
        /// <summary>
        /// Retrieve the title by its Id.
        /// </summary>
        /// <param name="id">The Id to search for, null if not found</param>
        /// <returns></returns>
        Title? GetTitleById(int id);
        /// <summary>
        /// Get titles with optional filtering and pagination.
        /// </summary>
        /// <param name="titleFilter">Request body to filter by. WILL CHANGE TO FILTER REQUEST</param>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Size per page</param>
        /// <returns>A list of applicable titles, empty if none</returns>
        List<Title> FindTitles(TitleUpdateRequest titleFilter, int page, int pageSize);
        /// <summary>
        /// Delete title by its Id
        /// </summary>
        /// <param name="id">The Id of the title to delete</param>
        /// <returns>Bool indicating success, false if not found</returns>
        bool DeleteTitle(int id);


        /// <summary>
        /// Create a new copy of a title in the inventory
        /// </summary>
        /// <param name="copy">The copy object to create</param>
        /// <returns>The newly created copy, with EntityBase updated</returns>
        TitleCopy CreateCopy(TitleCopy copy);
        /// <summary>
        /// Update an existing copy of a title in the inventory
        /// </summary>
        /// <param name="copy">The copy object to update</param>
        /// <returns>The newly updated copy, null if not found</returns>
        TitleCopy? UpdateCopy(TitleCopy copy);
        /// <summary>
        /// Get a copy by its Id
        /// </summary>
        /// <param name="id">The copy's id to fetch</param>
        /// <returns>The copy requested, null if not found</returns>
        TitleCopy? GetCopyById(int id);
        /// <summary>
        /// Get a list of copies by the title's Id
        /// </summary>
        /// <param name="titleId">The title Id to match</param>
        /// <returns>A list of copies matching, empty if none. Also includes checkout status if any</returns>
        List<TitleCopy> FindCopiesByTitleId(int titleId);
        /// <summary>
        /// Delete a copy by its Id
        /// </summary>
        /// <param name="id">The Id of the copy to delete</param>
        /// <returns>Bool indicating success, false if not found</returns>
        bool DeleteCopy(int id);


        /// <summary>
        /// Create a new author in the repository
        /// </summary>
        /// <param name="author">The author to save</param>
        /// <returns>The newly-saved author, with EntityBase updated</returns>
        TitleAuthor CreateAuthor(TitleAuthor author);
        /// <summary>
        /// Update an existing author in the repository
        /// </summary>
        /// <param name="author">The author to replace and update</param>
        /// <returns>The newly-updated author, null if not found</returns>
        TitleAuthor? UpdateAuthor(TitleAuthor author);
        /// <summary>
        /// Get an Author by its Id
        /// </summary>
        /// <param name="id">The Id of the author to fetch</param>
        /// <returns>The author found, null if not found</returns>
        TitleAuthor? GetAuthorById(int id);
        /// <summary>
        /// Search for an author by its name
        /// </summary>
        /// <param name="name">The name of the author to search for</param>
        /// <returns>A list of matching authors</returns>
        List<TitleAuthor> FindAuthorByName(string name);
        /// <summary>
        /// Delete an author by its Id
        /// </summary>
        /// <param name="id">The Id of the Author to delete</param>
        /// <returns>Bool indicating success, false if not found</returns>
        bool DeleteAuthor(int id);


        /// <summary>
        /// Create a new publisher in the repository
        /// </summary>
        /// <param name="publisher">The new publisher to save</param>
        /// <returns>The newly-saved publisher, with EntityBase updated</returns>
        TitlePublisher CreatePublisher(TitlePublisher publisher);
        /// <summary>
        /// Update a publisher in the repository
        /// </summary>
        /// <param name="publisher">The publisher to update</param>
        /// <returns>The newly-saved publisher, null if not found</returns>
        TitlePublisher? UpdatePublisher(TitlePublisher publisher);
        /// <summary>
        /// Find a publisher by its Id
        /// </summary>
        /// <param name="id">The Id of the publisher to find</param>
        /// <returns>The publisher found, null if none</returns>
        TitlePublisher? GetPublisherById(int id);
        /// <summary>
        /// Find all publishers matching the name provided
        /// </summary>
        /// <param name="name">The name to search for</param>
        /// <returns></returns>
        List<TitlePublisher> FindPublisherByName(string name);
        /// <summary>
        /// Delete a publisher by its Id
        /// </summary>
        /// <param name="id">The Id of the publisher to delete</param>
        /// <returns>Bool indicating success, false if not found</returns>
        bool DeletePublisher(int id);


        /// <summary>
        /// Create a new Genre in the repository
        /// </summary>
        /// <param name="genre">The new genre to create</param>
        /// <returns>The newly-cerated genre</returns>
        TitleGenre CreateGenre(TitleGenre genre);
        /// <summary>
        /// Update a genre in the repository
        /// </summary>
        /// <param name="genre">The genre to update</param>
        /// <returns>The newly-saved genre, null if not found</returns>
        TitleGenre? UpdateGenre(TitleGenre genre);
        /// <summary>
        /// Look up a genre by its Id
        /// </summary>
        /// <param name="id">The Id of the Genre to find</param>
        /// <returns>The genre, null if not found</returns>
        TitleGenre? GetGenreById(int id);
        /// <summary>
        /// Find all genres matching the name provided
        /// </summary>
        /// <param name="name">The genre to find</param>
        /// <returns>A list of genres found</returns>
        List<TitleGenre> FindGenreByName(string name);
        /// <summary>
        /// Delete a genre by its Id
        /// </summary>
        /// <param name="id">The Id of the Genre to delete</param>
        /// <returns></returns>
        bool DeleteGenre(int id);


        /// <summary>
        /// Create a new category in the repository
        /// </summary>
        /// <param name="category">The category to create</param>
        /// <returns>The newly-created category</returns>
        TitleCategory CreateCategory(TitleCategory category);
        /// <summary>
        /// Update a category in the repository
        /// </summary>
        /// <param name="category">The category to update</param>
        /// <returns>The newly-updated category, null if not found</returns>
        TitleCategory? UpdateCategory(TitleCategory category);
        /// <summary>
        /// Get a category by its Id
        /// </summary>
        /// <param name="id">The Id of the category to get</param>
        /// <returns>The category, null if not found</returns>
        TitleCategory? GetCategoryById(int id);
        /// <summary>
        /// Find categories matching the name provided
        /// </summary>
        /// <param name="name">The name to search for</param>
        /// <returns>A list of categories found</returns>
        List<TitleCategory> FindCategoryByName(string name);
        /// <summary>
        /// Delete a category by its Id
        /// </summary>
        /// <param name="id">The Id of the category to delete</param>
        /// <returns>Bool indicating success, false if not found</returns>
        bool DeleteCategory(int id);


        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user">The new user to create</param>
        /// <returns>The newly-created user, with EntityBase updated</returns>
        User CreateUser(User user);
        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="user">The user to save to the repository</param>
        /// <returns>The updated user, null if not found</returns>
        User? UpdateUser(User user);
        /// <summary>
        /// Get a user by its Id
        /// </summary>
        /// <param name="id">The Id of the user to get</param>
        /// <returns>The user found, null if not found</returns>
        User? GetUserById(int id);
        /// <summary>
        /// Find users matching the name provided, first and last
        /// </summary>
        /// <param name="name">The name to search for</param>
        /// <returns>A list of users matching the name</returns>
        List<User> FindUsersByName(string name);
        /// <summary>
        /// Delete a user by its Id
        /// </summary>
        /// <param name="id">The Id of the user to delete</param>
        /// <returns>Bool indicating success, false if not found</returns>
        bool DeleteUser(int id);


        /// <summary>
        /// Create a new user role in the repository
        /// </summary>
        /// <param name="role">The new role to save</param>
        /// <returns>The newly-created role</returns>
        UserRole CreateRole(UserRole role);
        /// <summary>
        /// Update a user role in the repository
        /// </summary>
        /// <param name="role">The role to save</param>
        /// <returns>The newly-updated role, null if not found</returns>
        UserRole? UpdateRole(UserRole role);
        /// <summary>
        /// Get a user role by its Id
        /// </summary>
        /// <param name="id">The Id of the role to get</param>
        /// <returns>The role found, null if not found</returns>
        UserRole? GetRoleById(int id);
        /// <summary>
        /// Find roles matching the name provided
        /// </summary>
        /// <param name="name">The name to search for</param>
        /// <returns>A list of matches roles</returns>
        List<UserRole> FindRoleByName(string name);
        /// <summary>
        /// Delete a role by its Id
        /// </summary>
        /// <param name="id">The Id of role to delete</param>
        /// <returns>Bool indicating success, false if not found</returns>
        bool DeleteRole(int id);


        /// <summary>
        /// Create a new user status in the repository
        /// </summary>
        /// <param name="status">The new status to create</param>
        /// <returns>The newly-created status</returns>
        UserStatus CreateStatus(UserStatus status);
        /// <summary>
        /// Update a user status in the repository
        /// </summary>
        /// <param name="status">The status to update</param>
        /// <returns>The newly-updated status, null if not found</returns>
        UserStatus? UpdateStatus(UserStatus status);
        /// <summary>
        /// Get a user status by its Id
        /// </summary>
        /// <param name="id">The status to find</param>
        /// <returns>Matched status, null if not found</returns>
        UserStatus? GetStatusById(int id);
        /// <summary>
        /// Find statuses matching the name provided
        /// </summary>
        /// <param name="name">The name to match</param>
        /// <returns>A list of matched Status names</returns>
        List<UserStatus> FindStatusByName(string name);
        /// <summary>
        /// Delete a user status by its Id
        /// </summary>
        /// <param name="id">The Id of the status to delete</param>
        /// <returns>Bool indicating success, false if not found</returns>
        bool DeleteStatus(int id);
    }
}
