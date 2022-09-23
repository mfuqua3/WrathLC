import {ItemSummary, Paginated, Wishlist} from "../domain/models";
import {GetWishlistOptionsRequest, UpdateCharacterWishlistRequest} from "../domain/requests";
import axios from "axios";

export interface WishlistsApi {
    getCharacterWishlist(characterId: number): Promise<Wishlist>;

    updateCharacterWishlist(request: UpdateCharacterWishlistRequest): Promise<Wishlist>;

    getWishlistOptions(request: GetWishlistOptionsRequest): Promise<Paginated<ItemSummary>>;
}

class WishlistsAccess implements WishlistsApi {
    private apiRoot = process.env.REACT_APP_API_ROOT + "/wishlists";

    async getCharacterWishlist(characterId: number): Promise<Wishlist> {
        const result = await axios.get<Wishlist>(`${this.apiRoot}/${characterId}`);
        return result.data;
    }

    async getWishlistOptions({
                                 characterId,
                                 ...queryParams
                             }: GetWishlistOptionsRequest): Promise<Paginated<ItemSummary>> {
        const result = await axios.get<Paginated<ItemSummary>>(`${this.apiRoot}/${characterId}/items`, {
            params: queryParams
        })
        return result.data;
    }

    async updateCharacterWishlist({characterId, ...body}: UpdateCharacterWishlistRequest): Promise<Wishlist> {
        const result = await axios.put<Wishlist>(`${this.apiRoot}/${characterId}`, body);
        return result.data;
    }


}

export default new WishlistsAccess() as WishlistsApi;