import { Box, Grid } from "@mui/material";

function Dashboard() {
  const datos = "datos";
  return (
    <Box>
      <Grid
        container
        spacing={2}
        sx={{
          display: "flex",
          justifyContent: "center",
          flexDirection: "column",
        }}
      >
        <Box sx={{ minWidth: 200, height: 200, border: "2px solid" }}>
          {datos}
        </Box>
        <Box sx={{ minWidth: 200, height: 200, border: "2px solid" }}>
          {datos}
        </Box>
        
      </Grid>
      
    </Box>
  );
}

export default Dashboard;
