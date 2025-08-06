import { Box, Button, TextField } from "@mui/material";

function Transaccion() {
  return (
    <Box>
      <Box
        sx={{
          display: "flex",
          justifyContent: "space-between",
        }}
      >
        <TextField
          sx={{
            width: "100%",
            px: 2,
          }}
        />
        <Button variant="contained" color="secondary">
          Agregar
        </Button>
      </Box>
      <Box
        sx={{
          border: "2px solid black",
          minHeight: 400,
          height: "auto",
          mt: "2rem",
        }}
      ></Box>
    </Box>
  );
}

export default Transaccion;
