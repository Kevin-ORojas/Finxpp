import { Box, Button, ButtonProps } from "@mui/material";
import SendIcon from "@mui/icons-material/Send";
import { FC } from "react";

// Componente tipado como FC con props de Button
const ButtonForm: FC<ButtonProps> = ({ children, ...props }) => {
  return (
    <Box>
      <Button
        type="submit"
        variant="contained"
        endIcon={<SendIcon />}
        {...props} // 👈 aquí entran disabled, onClick, etc.
      >
        {children}
      </Button>
    </Box>
  );
};

export default ButtonForm;
