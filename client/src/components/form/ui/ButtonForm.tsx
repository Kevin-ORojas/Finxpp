import { Box, Button } from "@mui/material";
import SendIcon from "@mui/icons-material/Send";

function ButtonForm() {
  return (
    <Box>
      <Button type="submit" variant="contained" endIcon={<SendIcon />}>
        Send
      </Button>
    </Box>
  );
}

export default ButtonForm;
