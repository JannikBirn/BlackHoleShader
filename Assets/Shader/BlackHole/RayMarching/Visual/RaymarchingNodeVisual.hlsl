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
    return length(float2(length(p.xz) - innerRadius, p.y))-outerRadius;
}

//
//Gravity
//
float3 GetGravity(float3 position, float3 direction, float STEP_SIZE, float SCHWARZSCHILD )
{
    return normalize((direction + ((position * -STEP_SIZE * (1.18f * SCHWARZSCHILD)) / pow( length(position), 3))));
}


float GetDistBlackHole(float3 position, float SCHWARZSCHILD){
    return GetDistSphere(position,float3(0,0,0),SCHWARZSCHILD);
}

void RaymarchHit(
    float3 position,
    float3 direction,
    float MAX_STEPS,
    float STEP_SIZE,
    float SCHWARZSCHILD,
    float2 accretionDisk,
    float4 AccretionDiskColor,
    out float4 color,
    out float3 nDir  )
{
    float dS = 0; //Distancae to Scene/Surface
    float3 lastPosition = position;

    color = float4(0,0,0,0);

    for(int i = 0; i < MAX_STEPS; i++)
    {
        //Calculate new position
        position += GetGravity(position,direction, STEP_SIZE, SCHWARZSCHILD) * STEP_SIZE;

        //Calculate new direction with new and old position
        direction = normalize(position - lastPosition);
        
        //Save new position
        lastPosition = position;

        if(position.y < 6 && position.y > -6)
            if(GetDistTorus(position,accretionDisk.x,accretionDisk.y) < STEP_SIZE){
                //Hit the accretionDisk
                color = AccretionDiskColor;
                break;
            }       

        if(GetDistBlackHole(position,SCHWARZSCHILD) < STEP_SIZE){
            //Hit the black hole
            color = float4(0,0,0,1);
            break;
        }
    }
    
    nDir = - direction;

}



void Raymarching_float(
    float3 position,
    float3 direction,
    float MAX_STEPS,
    float STEP_SIZE,
    float SCHWARZSCHILD,
    float2 accretionDisk,
    float4 AccretionDiskColor,
    out float4 color,
    out float3 nDirection)
{
    RaymarchHit(
        position,
        -normalize(direction),
        MAX_STEPS,
        STEP_SIZE,
        SCHWARZSCHILD,
        accretionDisk,
        AccretionDiskColor,
        color,
        nDirection);
}

#endif