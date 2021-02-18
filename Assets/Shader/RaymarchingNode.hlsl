#ifndef Raymarching_INCLUDED
#define Raymarching_INCLUDED

//
//Geometry
//
//Hit Condition
float GetDistSphere(float3 p, float3 centere, float radius){
    //Test if our position is inside of the sphere
    return distance(p,centere)-radius;
}

float GetDistTorus(float3 p, float innerRadius, float outerRadius)
{
    return length(float2(length(p.xy) - innerRadius, p.z))-outerRadius;
}

float GetDist(float3 p){
    return GetDistSphere(p,float3(1000,0,1000),100);
    // return 
    // min(GetDistSphere(p,float3(1000,0,1000),100),
    // GetDistTorus(p,0.5,0.1));
}

//
//Gravity
//
float3 GetGravity(float3 position, float3 direction, float STEP_SIZE, float SCHWARZSCHILD )
{
    return normalize((direction + ((position * STEP_SIZE * (1.18f * SCHWARZSCHILD)) / pow( length(position), 3))));
}


float GetDistBlackHole(float3 position, float SCHWARZSCHILD){
    return GetDistSphere(position,float3(0,0,0),SCHWARZSCHILD);
}


//w = 0 -> nothing
//  = 1 -> blackhole
//  = 2 -> geometry

void RaymarchHit(float3 position, float3 direction, float MAX_STEPS, float STEP_SIZE, float SCHWARZSCHILD, out bool insideBH, out float3 nDir  )
{
    float dS = 0; //Distancae to Scene/Surface
    float3 lastPosition = position;

    insideBH = false;

    for(int i = 0; i < MAX_STEPS; i++)
    {
        // dS = GetDist(position); //Get Distance to next surface

        //Calculate new position
        position += GetGravity(position,direction, STEP_SIZE, SCHWARZSCHILD) * STEP_SIZE;

        //Calculate new direction with new and old position
        direction = normalize(position - lastPosition);

        nDir = direction;
        
        //Save new position
        lastPosition = position;

        if(GetDistBlackHole(position,SCHWARZSCHILD) < 0){
            //Hit the black hole
            insideBH = true;
            break;
        }

        //  if(dS < STEP_SIZE)    {
        //     nPos = float4(position.xyz,2);  
        //     break;
        //  }             
    }

}



void Raymarching_float(float3 position, float3 direction, float MAX_STEPS, float STEP_SIZE, float SCHWARZSCHILD, out float3 color, out float3 nDirection){

    bool insideBH;
    float3 nDir;
    RaymarchHit(position,direction, MAX_STEPS, STEP_SIZE, SCHWARZSCHILD, insideBH,nDir);

    if(insideBH){
        color = float3(0,0,0);
    }else{
        color = float3(1,1,1);
    }    

    nDirection = nDir;
}

#endif