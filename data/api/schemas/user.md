
---

# Users - DTO Schemas

---

## Get

| Placeholder | Data Type | Nullable |
| -------- | -------- | -------- |
| **profilePic** | byte-array/string | `Yes` |
| **email** | string | `No` |
| **username** | string | `No` |
| **password** | string | `No` |

---

## Filter

| Placeholder | Data Type | Nullable |
| -------- | -------- | -------- |
| **email** | string | `Yes` |
| **username** | string | `Yes` |

---

## Create

| Placeholder | Data Type | Nullable |
| -------- | -------- | -------- |
| **email** | string | `No` |
| **username** | string | `No` |
| **password** | string | `No` |

> **Note:** The `password` must contail at least 8 characters.

---

## Update Email

| Placeholder | Data Type | Nullable |
| -------- | -------- | -------- |
| **email** | string | `No` |
| **password** | string | `No` |

> **Note:** For security purpose, user must enter his current password to update his/her email address.

---

## Update Username

| Placeholder | Data Type | Nullable |
| -------- | -------- | -------- |
| **username** | string | `No` |

---

## Update Password

| Placeholder | Data Type | Nullable |
| -------- | -------- | -------- |
| **oldPassword** | string | `No` |
| **newPassword** | string | `No` |
| **confirmPassword** | string | `No` |

> **Note:** To update password, user must enter his old password and also confirm his new password of at least 8 characters long.

---
