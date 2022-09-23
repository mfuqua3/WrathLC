import update from 'immutability-helper'
import React, {ReactNode, useCallback, useEffect, useState} from 'react'
import Card, {CardProps} from "./Card";
import {List, ListItemProps} from "@mui/material";
import {isHasId} from "../../utils/guards";


export interface ContainerState<T> {
    cards: T[]
    cardTemplate(item: T, isDragging: boolean, index: number): ReactNode
    listItemProps?(item: T, isDragging: boolean, index: number): ListItemProps;
    useId?(item: T): string | number;
    onDrop(state: T[]): void;
}

function Container<T extends object>(props: ContainerState<T>) {

    const [cards, setCards] = useState(props.cards)
    useEffect(() => {
        setCards(props.cards);
    }, [props.cards]);

    const moveCard = useCallback((dragIndex: number, hoverIndex: number) => {
        setCards((prevCards: T[]) =>
            update(prevCards, {
                $splice: [
                    [dragIndex, 1],
                    [hoverIndex, 0, prevCards[dragIndex] as T],
                ],
            }),
        )
    }, [])
    const handleCardDrop = useCallback(()=> {
        props.onDrop(cards);
    }, [cards])
    const renderCard =
        (card: T, index: number) => {
            let id: string | number;
            if (!!props.useId) {
                id = props.useId(card);
            } else {
                if (!isHasId(card)) {
                    throw Error("Unable to determine ID prop for the provided drag and drop card type.");
                }
                id = card.id;
            }
            const cardProps: CardProps<T> = {
                id: id,
                index,
                item: card,
                moveCard,
                renderCard: props.cardTemplate,
                onDrop: handleCardDrop,
                listItemProps: props.listItemProps ?? (() => undefined)
            }
            return (
                <Card
                    key={id}
                    {...cardProps}
                />
            )
        };

    return (
        <>
            <List>{cards.map((card, i) => renderCard(card, i))}</List>
        </>
    )

}

export default React.memo(Container);