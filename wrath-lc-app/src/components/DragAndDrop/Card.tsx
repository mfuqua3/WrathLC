import type {Identifier, XYCoord} from 'dnd-core'
import React, {ReactNode, useRef} from 'react'
import {useDrag, useDrop} from 'react-dnd'
import "../Wishlists/wishlists.css";
import {ItemTypes} from './ItemTypes'
import {ListItem, ListItemProps} from "@mui/material";

const style = {
    border: '1px dashed gray',
    padding: '0.5rem 1rem',
    marginBottom: '.5rem',
    backgroundColor: 'white',
    cursor: 'move',
}

export interface CardProps<T> {
    id: any
    item: T
    index: number
    moveCard: (dragIndex: number, hoverIndex: number) => void
    renderCard(item: T, isDragging: boolean, index: number): ReactNode
    listItemProps(item: T, isDragging: boolean, index: number): ListItemProps | undefined
    onDrop: () => void
}

interface DragItem {
    index: number
    id: string
    type: string
}

function Card<T extends object>({id, item, index, moveCard, renderCard, listItemProps, onDrop}: CardProps<T>) {
    const ref = useRef<HTMLLIElement>(null)
    const [{handlerId}, drop] = useDrop<DragItem,
        void,
        { handlerId: Identifier | null }>({
        accept: ItemTypes.CARD,
        collect(monitor) {
            return {
                handlerId: monitor.getHandlerId(),
            }
        },
        drop: onDrop,
        hover(item: DragItem, monitor) {
            if (!ref.current) {
                return
            }
            const dragIndex = item.index
            const hoverIndex = index

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
        },
    })

    const [{isDragging}, drag] = useDrag({
        type: ItemTypes.CARD,
        item: () => {
            return {id, index}
        },
        collect: (monitor: any) => ({
            isDragging: monitor.isDragging(),
        }),
    })
    drag(drop(ref))
    return (
        <ListItem ref={ref}
                  data-handler-id={handlerId}
                  {...listItemProps(item, isDragging, index)}>
            {renderCard(item, isDragging, index)}
        </ListItem>
    )
}

export default React.memo(Card);