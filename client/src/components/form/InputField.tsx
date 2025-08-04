import { Box, TextField } from "@mui/material";

function InputField() {
  return (
    <Box>
      <TextField label="Nombre" variant="outlined" value={name} fullWidth />
    </Box>
  );
}

export default InputField;
