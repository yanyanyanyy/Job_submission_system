<template>
    <div class="menu">
        <el-menu
                class="el-menu-demo"
                mode="horizontal"
                >
            <el-menu-item index="1">回到首页</el-menu-item>
        </el-menu>
        <div class="h-6" />
    </div>
</template>

<script>
    export default {
        name: "MenuPage",
    }
    
</script>
<style lang="scss" scoped>
    .menu{
        position:absolute;
        width: 100%;
        height: 100%;
        background-image: url('/images/svgs/login-bg.svg');
    }
</style>