import {ItemSummary, Paginated, Wishlist} from "../../domain/models";
import {PaginatedRequest, WishlistItemRequest} from "../../domain/requests";

export interface WishlistsState {
    wishlist: Wishlist | undefined;
    update(items: WishlistItemRequest[]): Promise<void>
    getOptions(filter: string, pagination?: PaginatedRequest): Promise<Paginated<ItemSummary>>
}