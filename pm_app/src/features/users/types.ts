import { User } from "../auth/types"

export type Users= {
    users: User[],
}
export type ItemCategoriesPaged= {
    items: User[],
    total: number,
    pageCount: number,
    pageIndex: number
}
