import {WishlistsContext} from "./WishlistsProvider";
import {useNullableContext} from "../../utils/hooks";

export function useWishlists() {
    return useNullableContext(WishlistsContext, "Wishlists");
}