import React, {ReactNode, useEffect, useState} from "react";
import {WishlistsState} from "./WishlistsState";
import {ItemSummary, Paginated, Wishlist} from "../../domain/models";
import {useApi} from "../../utils/hooks";
import {WishlistsApi} from "../../api";
import {PaginatedRequest, WishlistItemRequest} from "../../domain/requests";

export interface WishlistsProviderProps {
    characterId: number;
}

export const WishlistsContext = React.createContext<WishlistsState | null>(null);

function WishlistsProvider({children, ...props}: WishlistsProviderProps & { children: ReactNode }) {
    const [wishlist, setWishlist] = useState<Wishlist>();
    const api = useApi(WishlistsApi);
    useEffect(() => {
        api.invoke(x => x.getCharacterWishlist(props.characterId))
            .then(wishlist => setWishlist(wishlist));
    }, [props.characterId])

    async function update(items: WishlistItemRequest[]): Promise<void>{
        const updated = await api.invoke(x => x.updateCharacterWishlist({
            characterId: props.characterId,
            items
        }));
        setWishlist(updated);
    }
    async function getOptions(filter: string, pagination?: PaginatedRequest): Promise<Paginated<ItemSummary>>{
        return await api.invoke(x=>x.getWishlistOptions({
            filter,
            characterId: props.characterId,
            ...pagination
        }))
    }
    const state: WishlistsState = {
        wishlist, update, getOptions
    }
    return (
        <WishlistsContext.Provider value={state}>
            {children}
        </WishlistsContext.Provider>
    )
}

export default React.memo(WishlistsProvider);