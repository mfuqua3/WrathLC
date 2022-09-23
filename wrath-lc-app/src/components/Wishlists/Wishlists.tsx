import React, {useEffect, useState} from "react";
import {useWishlists} from "../../core/wishlists";
import {ItemSummary, WishlistItem} from "../../domain/models";
import {SearchInputProps} from "../SearchInput/SearchInput";
import {WishlistItemRequest} from "../../domain/requests";
import {SearchInput} from "../SearchInput";
import ItemComponent from "../Items/ItemComponent";
import {Avatar, Box, IconButton, ListItemAvatar, ListItemText} from "@mui/material";
import WowheadTooltip from "../UtilityWrappers/WowheadTooltip";
import ItemIcon from "../Icons/ItemIcon";
import "./wishlists.css";
import Container, {ContainerState} from "../DragAndDrop/Container";
import RemoveCircleOutlineIcon from '@mui/icons-material/RemoveCircleOutline';
import {HasId} from "../../domain/utility-types";
import ArrowUpwardIcon from '@mui/icons-material/ArrowUpward';
import ArrowDownwardIcon from '@mui/icons-material/ArrowDownward';

export interface WishlistsProps {
    enableReorderButtons?: boolean;
}

type StagedWishlistItem = WishlistItem & HasId;

function Wishlists(props: WishlistsProps) {
    const {wishlist, update, getOptions} = useWishlists();
    const itemRequestState: WishlistItemRequest[] = wishlist?.items.map(wishlistItem => ({
        orderNumber: wishlistItem.orderNumber,
        itemId: wishlistItem.item.itemId
    })) ?? [];
    const [stagedWishlistState, setStagedWishlistState] = useState<StagedWishlistItem[]>(
        wishlist?.items.map((item, idx) => ({...item, id: idx})) ?? []);
    const enableReorder = stagedWishlistState.length > 1 && (props.enableReorderButtons ?? false);
    useEffect(() => {
        if (wishlist) {
            setStagedWishlistState(wishlist.items.map((item, idx) => ({...item, id: idx})));
        }

    }, [wishlist]);

    async function handleSelection(item: ItemSummary) {
        await update([...itemRequestState, {orderNumber: itemRequestState.length, itemId: item.itemId}]);
    }

    async function handleUpdate(wishlistState: StagedWishlistItem[]) {
        const itemRequests: WishlistItemRequest[] = wishlistState.map(({item}, idx) => ({
            orderNumber: idx,
            itemId: item.itemId
        }))
        await update(itemRequests);
    }

    async function up(orderNumber: number){
        const currentIndex = stagedWishlistState.findIndex(x=>x.orderNumber === orderNumber);
        if(currentIndex < 1)
            return;
        const item = stagedWishlistState[currentIndex];
        const others = stagedWishlistState.filter(x=>x.orderNumber !== orderNumber);
        const requestState = [...others.slice(0, currentIndex - 1), item, ...others.slice(currentIndex - 1)];
        const itemRequests: WishlistItemRequest[] = requestState.map(({item}, idx) => ({
            orderNumber: idx,
            itemId: item.itemId
        }))
        await update(itemRequests);
    }
    async function down(orderNumber: number){
        const currentIndex = stagedWishlistState.findIndex(x=>x.orderNumber === orderNumber);
        if(currentIndex === -1 || currentIndex >= stagedWishlistState.length - 1)
            return;
        const item = stagedWishlistState[currentIndex];
        const others = stagedWishlistState.filter(x=>x.orderNumber !== orderNumber);
        const requestState = [...others.slice(0, currentIndex + 1), item, ...others.slice(currentIndex + 1)];
        const itemRequests: WishlistItemRequest[] = requestState.map(({item}, idx) => ({
            orderNumber: idx,
            itemId: item.itemId
        }))
        await update(itemRequests);
    }

    const searchInputProps: SearchInputProps = {
        fetchItems: getOptions,
        getItemId: (item) => item.itemId,
        onSelection: handleSelection,
        renderItem: (item) =>
            <WowheadTooltip {...item}>
                <ItemComponent item={item}/>
            </WowheadTooltip>
    }

    async function handleRemove(orderNumber: number) {
        const itemRequests: WishlistItemRequest[] = stagedWishlistState.filter(x => x.orderNumber !== orderNumber).map(({item}, idx) => ({
            orderNumber: idx,
            itemId: item.itemId
        }));
        await update(itemRequests);
    }

    const dragAndDropContainerProps: ContainerState<StagedWishlistItem> = {
        cards: stagedWishlistState,
        onDrop: handleUpdate,
        cardTemplate: ({item, orderNumber}: StagedWishlistItem, _, index) =>
            <>
                {
                    enableReorder &&
                    <>
                        <IconButton onClick={()=>up(orderNumber)}
                            disabled={index === 0} sx={{opacity: index === 0 ? 0 : 1}}>
                            <ArrowUpwardIcon/>
                        </IconButton>
                        <IconButton  onClick={()=>down(orderNumber)}
                            disabled={index + 1 === stagedWishlistState.length}
                                    sx={{opacity: index + 1 === stagedWishlistState.length ? 0 : 1}}>
                            <ArrowDownwardIcon/>
                        </IconButton>
                    </>
                }
                <ListItemAvatar>
                    <Avatar>
                        <WowheadTooltip {...item}>
                            <ItemIcon iconName={item.iconName} height={40}/>
                        </WowheadTooltip>
                    </Avatar>
                </ListItemAvatar>
                <ListItemText primary={
                    <Box component={"span"}>
                        {item.name}
                    </Box>} secondary={item.inventorySlot}/>
            </>,
        listItemProps: ({item, orderNumber}: StagedWishlistItem, isDragging: boolean) => ({
            dense: true,
            disablePadding: enableReorder,
            secondaryAction:
                <IconButton edge={"end"} aria-label={"delete"} color={"error"}
                            onClick={() => handleRemove(orderNumber)}>
                    <RemoveCircleOutlineIcon/>
                </IconButton>,
            style: {opacity: isDragging ? 0.4 : 1},
            className: `wishlist-item ${item.quality.toLowerCase()}`
        }),
    }
    return (
        <Box display={"flex"} flexDirection={"column"} height={"300px"}>
            <SearchInput {...searchInputProps} />
            {stagedWishlistState &&
                <Container {...dragAndDropContainerProps}/>
            }
        </Box>
    )
}


export default React.memo(Wishlists);