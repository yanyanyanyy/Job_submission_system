<template>
    <el-aside id="treeView">
        <el-tree v-show="treeView" :data="treeView" :props="treeProps" @node-click="FileTreeClick">

        </el-tree>
    </el-aside>
    <el-main>
        <el-card class="box-card">
            <template #header>
                <div class="card-header">
                    <span>{{filename}}</span>
                    <el-button class="button" text>Operation button</el-button>
                </div>
            </template>
            <el-scrollbar height="600px">
                <el-text class="code">{{ code_data }}</el-text>
            </el-scrollbar>
        </el-card>
    </el-main>
</template>

<script>
    import axios from '../../api/config' 
    export default {
        name: "FileTree",

        data() {
            return {
                treeView: null,
                treeProps: {
                    children: 'sonNodes',
                    label: 'filename'
                },
                code_data: null,
                filename: null
            }
        },
        methods: {
            FileTreeClick(data) {
                this.code_data = data.fileInformation.code;
                this.filename = data.filename;
            }
        },
        created() {
            //console.log(this.treeView)
            axios.get('api/CorrectionInfor').then(
                response => (this.treeView = [response.data.treeView])
            )
            console.log(this.treeView)
        }
    };
</script>

<style>
    #treeView{
        width:300px;
        float:Left;
    }
    .code {
        white-space: pre;
    }
    .box-card {
        height: 90;
    }
</Style>
