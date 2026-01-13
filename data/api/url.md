
---

# Base URLs

- **Host:** ```https://blogora-production.up.railway.app```
- **API:** ```[Host]/api/```

---

# APIs

**Note:** Every API uses DTOs to transfer data and they are inherited with [global-DTOs](/data/api/schemas/global.md). The pattern is:
- **`GET` - All / By Id:** It is inherited with global get DTO which contains `id`, `created-at`, and `updated-at` logs.
- **`GET` - All filtered:** It is inherited with global filter DTO which containes only `page-number` and `page-size` for pagination filtering/results.
- **`DELETE`:** It is inherited with global delete DTO which contains only `id` for reference.

---

## User APIs

*See schemas for more information about [User DTOs](/data/api/schemas/user.md).*

- **GET:** There're some ways to get user data:
    - **By Id:** To get user by id use this: `[API]/users/{id}`
    - **All (Filtered):** To get all users with filter and pagination use this: `[API]/users/{filter-dto}`
    - **All:** To get all users without any filter use this: `[API]/users/`

- **POST:** There's a single way to add a new user:
    - To create a new user use this: `[API]/users/{create-dto}`

- **PUT:** There're multiple ways to update user:
    - **Profile Pic:** To update profile pic of the user you can use this: `[API]/users/update/profile-pic/{update-profile-pic-dto}`
    - **Email:** To update email of a user (inspired feature from [LinkedIn](linkedin.com)) you can use this: `[API]/users/update/email/{update-email-dto}`
    - **Username:** To update the username of a user use this: `[API]/users/update/username/{update-username-dto}`
    - **Password:** To update the user's password use this: `[API]/users/update/username/{update-password-dto}`

- **DELETE:** There's a single way to delete a user from database is:
    - To delete a user use this: ```[API]/users/{id}```

---

## Blog APIs

*See schemas for more information about [Blog DTOs](/data/api/schemas/blog.md)*

- **GET:** There're some ways to get blog data:
    - **By Id:** To get blog by id use this: `[API]/blogs/{id}`
    - **All (Filtered):** To get all blogs with filter and pagination use this: `[API]/blogs/{filter-dto}`
    - **All:** To get all blogs without any filter use this: `[API]/blogs/`
- **POST:** There's a single way to create a new blog:
    - To create a blog use this: `[API]/blogs/{create-dto}`
- **PUT:** There're mutliple ways to update blog:
    - **Featured Image:** You can change/remove featured image of the blog by using this: `[API]/blogs/update/image/{update-image-dto}`
    - **Title:** You can change title of the blog by using this: `[API]/blogs/update/title/{update-title-dto}`
    - **Description:** You can change description of the blog by using this: `[API]/blogs/update/description/{update-description-dto}`
- **DELETE:** There's a single way to delete a blog:
    - To delete a blog use this: `[API]/blogs/{id}`

---
