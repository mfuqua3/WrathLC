import * as yup from "yup";

export const ChangeCharacterNameValidationSchema = yup.object().shape({
    name: yup.string().required(),
    characterId: yup.number().required("A character must be specified").min(1, "A character must be specified"),
});