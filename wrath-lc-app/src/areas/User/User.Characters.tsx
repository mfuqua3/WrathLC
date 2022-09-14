import React, {useState} from "react";
import CardPresentationLayout from "../../components/Layouts/CardPresentationLayout";
import {Button, Stack, Tooltip} from "@mui/material";
import AddIcon from '@mui/icons-material/Add';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import useUserCharacters from "../../core/characters/useUserCharacters";
import {DataGrid, GridActionsCellItem, GridColumns} from "@mui/x-data-grid";
import ClassIcon from "../../components/Icons/ClassIcon";
import CheckIcon from '@mui/icons-material/Check';
import {Character} from "../../domain/models";
import {useModal} from "../../utils/modal";
import {ChangeCharacterNameDialog, CreateCharacterDialog} from "../../components/Dialogs";
import {CreateCharacterParameters} from "../../core/characters";
import {useConfirmation} from "../../utils/hooks";
import {ChangeCharacterNameRequest} from "../../domain/requests";
import {ResponsiveIconButton} from "../../components/Buttons";

function UserCharacters() {
    const [editing, setEditing] = useState(false);
    const characterState = useUserCharacters();
    const {showModal, hideModal} = useModal("medium");
    const showDialog = useConfirmation();

    async function handleCreateCharacter(params: CreateCharacterParameters): Promise<void> {
        await characterState.createNew(params);
        hideModal();
    }
    async function handleChangeCharacterName(params: ChangeCharacterNameRequest) : Promise<void>{
        await characterState.changeCharacterName(params);
        hideModal();
    }

    const columns: GridColumns<Character> = [
        {
            field: "edit", type: "actions", width: 80, hideable: true,
            getActions: (params) => [
                <Tooltip title={"Change Character Name"} key={'edit-action'}>
                    <GridActionsCellItem label={""} icon={<EditIcon/>}
                    onClick={()=>showModal(<ChangeCharacterNameDialog character={params.row} onSubmit={handleChangeCharacterName} />)}/>
                </Tooltip>,
                <Tooltip title={"Delete"} key={'delete-action'}>
                    <GridActionsCellItem label={""} icon={<DeleteIcon/>}
                                         onClick={() => showDialog({
                                             title: `Delete ${params.row.name}?`,
                                             prompt: "This will archive this character and its history. Restoring this character will require intervention my the server administrator.",
                                             confirmColor: "error",
                                             onConfirmed: () => characterState.deleteCharacter(params.row.id)
                                         })}/>
                </Tooltip>
            ]
        },
        {
            field: "class", headerName: "Class", width: 75, headerAlign: "center", align: "center",
            renderCell: (character) => <ClassIcon wowClass={character.row.class} height={40}/>
        },
        {field: "name", headerName: "Character Name", minWidth: 150, headerAlign: "center"},
        {
            field: "isPrimary", headerName: "Main?", width: 100, align: "center", headerAlign: "center",
            renderCell: (character) => character.row.isPrimary ? <CheckIcon/> : <></>
                // <Button color={"secondary"} variant={"contained"} disabled={!editing}>Set Main</Button>
        }
    ];
    return (
        <CardPresentationLayout title={"Your Characters"}
                                action={
                                    <Stack direction={"row"} spacing={1}>
                                        <ResponsiveIconButton icon={<EditIcon/>} label={"Toggle Edit Mode"}
                                                              onClick={() => setEditing(prev => !prev)} />
                                        <ResponsiveIconButton icon={<AddIcon/>}  label={"Add Character"}
                                                              onClick={() => showModal(<CreateCharacterDialog
                                            onSubmit={handleCreateCharacter}/>)} />
                                    </Stack>
                                }>
            <DataGrid columns={columns}
                      getRowId={(char) => char.id}
                      rows={characterState.characters ?? []}
                      loading={!characterState.characters}
                      columnVisibilityModel={{
                          edit: editing,
                          class: true,
                          name: true,
                          isPrimary: true
                      }}/>
        </CardPresentationLayout>
    )

}

export default React.memo(UserCharacters);