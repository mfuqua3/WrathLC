import React, {ChangeEvent, useEffect, useRef, useState} from "react";
import {Box, LinearProgress, MenuItem, Paper, Stack, TextField, Typography} from "@mui/material";
import {PaginatedRequest} from "../../domain/requests";
import {ItemSummary, Paginated} from "../../domain/models";
import useDebounce from "../../utils/hooks/useDebouce";
import ClickOutsideWrapper from "../UtilityWrappers/ClickOutsideWrapper";

export interface SearchInputProps {
    fetchItems(filter: string, pagination: PaginatedRequest): Promise<Paginated<ItemSummary>>;

    renderItem: (item: ItemSummary) => JSX.Element;
    onSelection: (item: ItemSummary) => void;
    getItemId: (item: ItemSummary) => number | string;
}


function SearchInput(props: SearchInputProps) {
    const inputRef = useRef<HTMLDivElement>(null);
    const [filter, setFilter] = useState("");
    const debouncedFilter = useDebounce(filter, 250);
    const [options, setOptions] = useState<ItemSummary[]>([]);
    const [searchOpen, setSearchOpen] = useState(false);
    const [searching, setSearching] = useState(false);
    useEffect(() => {
        if (!searchOpen) {
            return;
        }
        if (debouncedFilter === "" || debouncedFilter.length < 2) {
            setOptions([]);
            return;
        }
        setSearching(true);
        props.fetchItems(debouncedFilter, {page: 0, pageSize: 10})
            .then(result => setOptions(result.items))
            .finally(() => setSearching(false));
    }, [debouncedFilter]);

    function handleChange(e: ChangeEvent<HTMLInputElement>) {
        setFilter(e.currentTarget.value);
    }

    function handleSelection(item: ItemSummary) {
        setSearchOpen(false);
        setFilter("");
        props.onSelection(item);
    }

    return (
        <>
            <ClickOutsideWrapper action={() => setSearchOpen(false)}
                                 isOpen={searchOpen}>
                <TextField
                    placeholder={"Search for items to add to your wishlist"}
                    autoComplete={"off"}
                    fullWidth
                    value={filter}
                    ref={inputRef}
                    onClick={() => setSearchOpen(true)}
                    onChange={handleChange}
                />
            <Paper sx={() => ({
                display: searchOpen ? "block" : "none",
                p: 1,
                width: inputRef.current?.offsetWidth,
                position: "absolute",
                zIndex: 10000,
                left: inputRef.current?.offsetLeft,
                top: ((inputRef.current?.offsetTop ?? 0) + (inputRef.current?.offsetHeight ?? 0))
            })}>
                {
                    searching ?
                        <Box>
                            <Stack width={"100%"} justifyContent={"center"} spacing={2}>
                                <Typography>Searching.... </Typography>
                                <LinearProgress/>
                            </Stack>
                        </Box> :
                        filter.length < 2 ?
                            <MenuItem>Search for an item....</MenuItem> :
                            options.length > 0 ?
                                options
                                    .map(item =>
                                        (<MenuItem key={props.getItemId(item)}
                                                   onClick={() => handleSelection(item)}>{props.renderItem(item)}
                                        </MenuItem>)) :
                                <MenuItem>No results</MenuItem>
                }

            </Paper>

            </ClickOutsideWrapper>
        </>
    );
}

export default React.memo(SearchInput);
