import { Box, Grid } from "@mui/material";

function Dashboard() {
  const datos = "datos";
  return (
    <Box
      sx={{
        backgroundColor: "#4643A2",
        minHeight: 600,
        borderRadius: 4,
      }}
    >
      <Grid
        container
        spacing={14}
        sx={{
          display: "flex",
          justifyContent: "space-around",
          p: 2,
        }}
      >
        <Box
          sx={{
            minWidth: 300,
            height: 200,
            border: "2px solid",
            borderRadius: 10,
          }}
        >
          {datos}
        </Box>
        <Box
          sx={{
            minWidth: 300,
            height: 200,
            border: "2px solid",
            borderRadius: 10,
          }}
        >
          {datos}
        </Box>
        <Box
          sx={{
            minWidth: 300,
            height: 200,
            border: "2px solid",
            borderRadius: 10,
          }}
        >
          {datos}
        </Box>
      </Grid>
      <Grid
        container
        spacing={14}
        sx={{
          display: "flex",
          justifyContent: "space-around",
          p: 2,
        }}
      >
        <Box
          sx={{
            minWidth: 600,
            height: 300,
            border: "2px solid",
            borderRadius: 10,
          }}
        >
          {datos}
        </Box>
        <Box
          sx={{
            minWidth: 300,
            height: 300,
            border: "2px solid",
            borderRadius: 10,
          }}
        >
          {datos}
        </Box>

        <Box
          sx={{
            minWidth: "100%",
            height: 300,
            border: "2px solid",
            borderRadius: 10,
          }}
        >
          {datos}
        </Box>
      </Grid>
    </Box>
  );
}

export default Dashboard;
