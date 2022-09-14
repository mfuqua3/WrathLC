import {WishlistItem} from "./WishlistItem";

export interface Wishlist {
    lastUpdated: Date;
    items: WishlistItem[];
}

