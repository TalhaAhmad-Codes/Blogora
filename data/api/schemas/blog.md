
---

# Blog - DTOs Schemas

---

## Get / Create

| Placeholder | Data Type | Nullable |
|-------------|-----------|----------|
| **authorId** | int | `No` |
| **featuredImage** | byte-array | `Yes` |
| **title** | string | `No` |
| **description** | string | `No` |

> **Note:** For featured-image, byte conversion is important.

---

## Filter

| Placeholder | Data Type | Nullable |
|-------------|-----------|----------|
| **authorId** | int | `Yes` |
| **reactionOfUserId** | int | `Yes` |
| **commentOfUserId** | int | `Yes` |
| **minReactionsCount** | int | `Yes` |
| **maxReactionsCount** | int | `Yes` |
| **minCommentsCount** | int | `Yes` |
| **maxCommentsCount** | int | `Yes` |

---

## Update Featured Image

| Placeholder | Data Type | Nullable |
|-------------|-----------|----------|
| **featuredImage** | byte-array | `Yes` |

> **Note:** For featured-image, byte conversion is important.

---

## Update Title

| Placeholder | Data Type | Nullable |
|-------------|-----------|----------|
| **title** | string | `No` |

---

## Update Description

| Placeholder | Data Type | Nullable |
|-------------|-----------|----------|
| **description** | string | `No` |

---
