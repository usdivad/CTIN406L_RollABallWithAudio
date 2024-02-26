/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_AMB_CITY_LP = 584628495U;
        static const AkUniqueID PLAY_AMB_CITYFORESTBLEND = 2948244008U;
        static const AkUniqueID PLAY_AMB_DOGBARKS = 791217870U;
        static const AkUniqueID PLAY_AMB_FOREST_LP = 149137005U;
        static const AkUniqueID PLAY_AMB_INTERIOR_LP = 93749488U;
        static const AkUniqueID PLAY_FLY_FOOTSTEP = 958544762U;
        static const AkUniqueID PLAY_IMP_PICKUP = 3369882767U;
        static const AkUniqueID PLAY_IMP_WALL_2D = 1947854728U;
        static const AkUniqueID PLAY_IMP_WALL_3D = 1964632347U;
        static const AkUniqueID PLAY_MUS_BGM_INTERACTIVE = 96395413U;
        static const AkUniqueID PLAY_MUS_MAIN = 4165304245U;
        static const AkUniqueID PLAY_MVT_BALLROLLING_LP = 4193143717U;
        static const AkUniqueID PLAY_UI_WIN = 2823495579U;
        static const AkUniqueID STOP_AMB_INTERIOR_LP = 2159561926U;
        static const AkUniqueID TRIGGER_MUS_PICKUP = 3340362146U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace STA_GAMESTATE
        {
            static const AkUniqueID GROUP = 530992273U;

            namespace STATE
            {
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID STA_GAMESTATE_PLAYING = 1888728998U;
                static const AkUniqueID STA_GAMESTATE_WIN = 2087516798U;
            } // namespace STATE
        } // namespace STA_GAMESTATE

        namespace STA_MUSICSECTION
        {
            static const AkUniqueID GROUP = 387365902U;

            namespace STATE
            {
                static const AkUniqueID A = 84696446U;
                static const AkUniqueID B = 84696445U;
                static const AkUniqueID C = 84696444U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace STA_MUSICSECTION

    } // namespace STATES

    namespace SWITCHES
    {
        namespace SWI_CRATETYPE
        {
            static const AkUniqueID GROUP = 236169936U;

            namespace SWITCH
            {
                static const AkUniqueID SWI_CRATETYPE_COMMON = 2649394644U;
                static const AkUniqueID SWI_CRATETYPE_RARE = 1167673431U;
                static const AkUniqueID SWI_CRATETYPE_UNCOMMON = 2693566681U;
            } // namespace SWITCH
        } // namespace SWI_CRATETYPE

        namespace SWI_FOOTSTEPMATERIAL
        {
            static const AkUniqueID GROUP = 3045844422U;

            namespace SWITCH
            {
                static const AkUniqueID CONCRETE = 841620460U;
                static const AkUniqueID GRASS = 4248645337U;
            } // namespace SWITCH
        } // namespace SWI_FOOTSTEPMATERIAL

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID RTPC_BALLSPEED = 3709966389U;
        static const AkUniqueID RTPC_COLLISIONVELOCITYNORMALIZED = 1573010119U;
        static const AkUniqueID RTPC_PLAYERDISTANCE = 3045223865U;
        static const AkUniqueID RTPC_PLAYERSPEED = 2653406601U;
    } // namespace GAME_PARAMETERS

    namespace TRIGGERS
    {
        static const AkUniqueID MUS_PICKUP = 965785689U;
    } // namespace TRIGGERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAINSOUNDBANK = 534561221U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID AMB = 1117531639U;
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUS = 712897226U;
        static const AkUniqueID RVB = 695384145U;
        static const AkUniqueID SFX = 393239870U;
    } // namespace BUSSES

    namespace AUX_BUSSES
    {
        static const AkUniqueID RVB_LARGEHALL = 1985046648U;
    } // namespace AUX_BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
