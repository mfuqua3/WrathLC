import {WishlistItemRequest} from "./WishlistItemRequest";

export interface UpdateCharacterWishlistRequest {
    items: WishlistItemRequest[];
    characterId: number;
}