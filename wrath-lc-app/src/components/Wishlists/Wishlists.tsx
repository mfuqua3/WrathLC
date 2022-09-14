import React, {useRef} from "react";
import {useWishlists} from "../../core/wishlists";
import {ItemSummary, WishlistItem} from "../../domain/models";
import {SearchInputProps} from "../SearchInput/SearchInput";
import {WishlistItemRequest} from "../../domain/requests";
import {SearchInput} from "../SearchInput";
import ItemComponent from "../Items/ItemComponent";
import {Avatar, Box, List, ListItem, ListItemAvatar, ListItemText} from "@mui/material";
import WowheadTooltip from "../UtilityWrappers/WowheadTooltip";
import ItemIcon from "../Icons/ItemIcon";
import "./wishlists.css";
import {useDrag, useDrop} from "react-dnd";
import type { Identifier, XYCoord } from 'dnd-core'

function Wishlists() {
    const {wishlist, update, getOptions} = useWishlists();
    const itemRequestState: WishlistItemRequest[] = wishlist?.items.map(wishlistItem => ({
        orderNumber: wishlistItem.orderNumber,
        itemId: wishlistItem.item.itemId
    })) ?? [];

    async function handleSelection(item: ItemSummary) {
        await update([...itemRequestState, {orderNumber: itemRequestState.length, itemId: item.itemId}]);
    }

    const searchInputProps: SearchInputProps = {
        fetchItems: getOptions,
        getItemId: (item) => item.name,
        onSelection: handleSelection,
        renderItem: (item) =>
            <WowheadTooltip {...item}>
                <ItemComponent item={item}/>
            </WowheadTooltip>
    }

    async function handleDragEnd(dragIndex: number, hoverIndex: number) {
        console.log("drag" + dragIndex);
        console.log("hover" + hoverIndex);
    }

    return (
        <Box display={"flex"} flexDirection={"column"} height={"300px"}>
            <SearchInput {...searchInputProps} />
            {wishlist?.items &&
                <List>
                    {wishlist.items.map(wi=><WishlistDragAndDropItem moveCard={handleDragEnd} key={wi.item.itemId} wishlistItem={wi} />)}
                </List>
            }
        </Box>
    )
}

interface DragItem {
    index: number
    id: string
    type: string
}

interface WishlistDragAndDropItemProps {
    wishlistItem: WishlistItem
    moveCard: (dragIndex: number, hoverIndex: number) => void
}

function WishlistDragAndDropItem({wishlistItem, moveCard}: WishlistDragAndDropItemProps) {
    const ref = useRef<HTMLLIElement>(null);
    const [{ handlerId }, drop] = useDrop<DragItem, void, {handlerId: Identifier | null}>({
        accept: "WishlistItem",
        collect(monitor) {
            return {
                handlerId: monitor.getHandlerId()
            }
        },
        hover(item: DragItem, monitor) {
            if (!ref.current) {
                return
            }
            const dragIndex = item.index
            const hoverIndex = wishlistItem.orderNumber

            // Don't replace items with themselves
            if (dragIndex === hoverIndex) {
                return
            }

            // Determine rectangle on screen
            const hoverBoundingRect = ref.current?.getBoundingClientRect()

            // Get vertical middle
            const hoverMiddleY =
                (hoverBoundingRect.bottom - hoverBoundingRect.top) / 2

            // Determine mouse position
            const clientOffset = monitor.getClientOffset()

            // Get pixels to the top
            const hoverClientY = (clientOffset as XYCoord).y - hoverBoundingRect.top

            // Only perform the move when the mouse has crossed half of the items height
            // When dragging downwards, only move when the cursor is below 50%
            // When dragging upwards, only move when the cursor is above 50%

            // Dragging downwards
            if (dragIndex < hoverIndex && hoverClientY < hoverMiddleY) {
                return
            }

            // Dragging upwards
            if (dragIndex > hoverIndex && hoverClientY > hoverMiddleY) {
                return
            }

            // Time to actually perform the action
            moveCard(dragIndex, hoverIndex)

            // Note: we're mutating the monitor item here!
            // Generally it's better to avoid mutations,
            // but it's good here for the sake of performance
            // to avoid expensive index searches.
            item.index = hoverIndex
        }
    })
    const [{ isDragging }, drag] = useDrag({
        type: "WishlistItem",
        item: () => {
            return { id: wishlistItem.item.itemId, index: wishlistItem.orderNumber }
        },
        collect: (monitor: any) => ({
            isDragging: monitor.isDragging(),
        }),
    })
    const opacity = isDragging ? 0 : 1
    drag(drop(ref))
    return (
        <ListItem ref={ref} data-handler-id={handlerId} className={`wishlist-item ${wishlistItem.item.quality.toLowerCase()}`}>
            <ListItemAvatar>
                <Avatar>
                    <WowheadTooltip {...wishlistItem.item}>
                        <ItemIcon iconName={wishlistItem.item.iconName} height={40}/>
                    </WowheadTooltip>
                </Avatar>
            </ListItemAvatar>
            <ListItemText primary={
                <Box component={"span"}>
                    {wishlistItem.item.name}
                </Box>} secondary={wishlistItem.item.inventorySlot}/>
        </ListItem>
    )
}

export default React.memo(Wishlists);